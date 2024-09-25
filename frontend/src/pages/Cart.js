import React, { useState, useEffect, useContext } from 'react';
import displayCurrencyRSD from '../helpers/displayCurrency';
import { IoCloseSharp } from "react-icons/io5";
import Context from '../context';
import { useStripe } from '@stripe/react-stripe-js';
import axios from 'axios';
import { useSelector } from 'react-redux';
import { loadStripe } from '@stripe/stripe-js';

const Cart = () => {
  const user = useSelector((state) => state?.user?.user);
  const context = useContext(Context);

  const { cartCount, setCartCount } = useContext(Context);
  const [data, setData] = useState([]);
  const stripe = useStripe();

  useEffect(() => {
    const storedCart = JSON.parse(localStorage.getItem('cart')) || [];
    setData(storedCart);
  }, []);

  const handlePayment = async () => {

    const stripePromise = await loadStripe("pk_test_51LmepVKiG1tYFgD1PO9vuaekHqSRcSWYyrTCL0fqsVysHsPXRvuZHAIOzkm7HjnMMU4zz1e6YkNNEqCRgCs5Odjn00udg25zRX");

  

    const orderItems = data.map(item => ({
        productId: item.productId,
        quantity: item.quantity
    }));

    console.log("Order Items:", orderItems); 

    const orderData = {
        isPaid: false,
        userId: user?.user?.userId 
    };

    console.log(orderData)

    try {
        const response = await fetch('https://localhost:7123/orders', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
              isPaid: orderData?.isPaid,
              userId: orderData?.userId
            }),
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        } 

        
        const orderResponse = await response.json();
        console.log("Order Response:", orderResponse); // Log the response
        const orderResponseId = orderResponse.orderId;
        console.log("Order Id: ", orderResponseId)


            // Assuming orderItems is an array of items you want to create
        for (const item of orderItems) {
          const orderItemResponse = await fetch('https://localhost:7123/order-items', {
              method: 'POST',
              headers: {
                  'Content-Type': 'application/json',
              },
              body: JSON.stringify({
                  productId: item.productId, // Replace with the correct property from your item
                  orderId: orderResponseId,
                  quantity: item.quantity
              }),
          });

          if (!orderItemResponse.ok) {
              throw new Error(`HTTP error while creating order item! status: ${orderItemResponse.status}`);
          }

          const orderItemData = await orderItemResponse.json();
          console.log("Created Order Item:", orderItemData);
        }


        


        const sessionResponse = await fetch(`https://localhost:7123/stripe-session/${orderResponseId}`, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
            },
            
        });

        console.log("Sesija: ", sessionResponse)

        if (!sessionResponse.ok) {
            throw new Error(`HTTP error! status: ${sessionResponse.status}`);
        }

        const { sessionId: id } = await sessionResponse.json();
        console.log(id)
        

        const { error } = await stripePromise.redirectToCheckout({ sessionId : id });

        if (error) {
            console.error("Stripe Checkout error:", error);
        }
    } catch (error) {
        console.error("Payment error:", error);
    }
};


  const deleteCartProduct = (productId) => {
    const updatedCart = data.filter(item => item.productId !== productId);
    setData(updatedCart);
    localStorage.setItem('cart', JSON.stringify(updatedCart));
    setCartCount(updatedCart.length);
  };

  const decreaseQuantity = (productId) => {
    const updatedCart = data.map(item => {
      if (item.productId === productId) {
        if (item.quantity > 1) {
          item.quantity -= 1;
        } else {
          return null;
        }
      }
      return item;
    }).filter(Boolean);
    setData(updatedCart);
    localStorage.setItem('cart', JSON.stringify(updatedCart));
  };

  const increaseQuantity = (productId) => {
    const updatedCart = data.map(item => {
      if (item.productId === productId) {
        item.quantity += 1;
      }
      return item;
    });
    setData(updatedCart);
    localStorage.setItem('cart', JSON.stringify(updatedCart));
  };

  return (
    <div className="container mx-auto">
      <div className="text-center text-lg my-3">
        {data.length === 0 && <p className="bg-white py-5">No Data</p>}
      </div>

      <div className="flex flex-col lg:flex-row gap-10 lg:justify-between p-4">
        <div className="w-full max-w-3xl">
          {data.map(product => (
            <div key={product._id} className="w-full bg-white h-32 my-2 border border-slate-300 rounded grid grid-cols-[128px,1fr]">
              <div className="w-32 h-32 bg-slate-200 flex justify-center items-center">
                <img src={product.image} className="w-full h-full object-scale-down" alt={product.name} />
              </div>
              <div className="px-4 py-2 relative">
                <div className="absolute right-0 text-red-600 rounded-full p-2 mr-1 hover:bg-red-600 hover:text-white cursor-pointer" onClick={() => deleteCartProduct(product.productId)}>
                  <IoCloseSharp />
                </div>
                <h2 className="text-lg lg:text-xl text-ellipsis line-clamp-1">{product.name}</h2>
                <p className="capitalize text-slate-500">{product.category}</p>
                <div className="flex items-center justify-between">
                  <p className="font-medium text-lg">{displayCurrencyRSD(product.price * product.quantity)}</p>
                </div>
                <div className="flex items-center gap-3 mt-1 border w-fit">
                  <button className="border text-slate-600 hover:bg-orange-300 hover:text-white w-6 h-6 flex justify-center items-center rounded" onClick={() => decreaseQuantity(product.productId)}>-</button>
                  <span>{product.quantity}</span>
                  <button className="border text-slate-600 hover:bg-orange-300 hover:text-white w-6 h-6 flex justify-center items-center rounded" onClick={() => increaseQuantity(product.productId)}>+</button>
                </div>
              </div>
            </div>
          ))}
        </div>

        <div className="mt-5 lg:mt-0 w-full max-w-sm border h-fit">
          <div className="bg-white">
            <h2 className="text-white font-semibold bg-orange-300 px-4 py-1 text-center mb-6">Summary</h2>
            <div className="flex items-center justify-between px-4 py-1 gap-2 font-medium text-md text-slate-600">
              <p>Quantity</p>
              <p>{data.reduce((acc, item) => acc + item.quantity, 0)}</p>
            </div>
            <div className="flex items-center justify-between px-4 py-2 gap-2 font-medium text-md text-slate-600">
              <p>Total Price</p>
              <p>{displayCurrencyRSD(data.reduce((acc, item) => acc + item.price * item.quantity, 0))}</p>
            </div>
            <button className="bg-blue-500 hover:bg-blue-700 p-2 text-white font-semibold w-full mt-6 flex justify-center items-center" onClick={handlePayment}>
              Pay with Stripe
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Cart;
