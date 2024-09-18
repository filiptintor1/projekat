import React, { useState } from 'react'
import logo from "../assets/honeycomb.png"
import { IoCartOutline } from "react-icons/io5";
import { Link } from 'react-router-dom';
import { FaUserCircle } from "react-icons/fa";



const Header = () => {

  const [isLoggedIn, setIsLoggedIn] = useState(false)


  return (
    <header className='h-16 shadow-sm bg-white fixed w-full z-40'>
      <div className='h-full container mx-auto flex items-center px-4 justify-between'>
        
        {/**LOGO */}
        <div className='flex justify-center items-center'>
          <img src={logo} width={34} className='mr-2'/>
          <div className='font-bold'>HoneyStore</div>
        </div>

        {/**Navigacija */}
        <div className='flex justify-center items-center ml-12'>
          <nav className='flex justify-center items-center'>
            <Link
              to={'/'}
              className='hidden md:block hover:bg-orange-300 transition-all px-3 py-1 mx-2'
            >
              Home
            </Link>
            <Link
              to={'/aboutUs'}
              className='hidden md:block hover:bg-orange-300 transition-all px-3 py-1 mx-2'
            >
              About Us
            </Link>
            <Link
              to={'/shop'}
              className='hidden md:block hover:bg-orange-300 transition-all px-2 py-1 mx-2'
            >
              Shop
            </Link>
          </nav>

        </div>


        <div className='flex justify-center items-center'>
          <IoCartOutline className='text-3xl mx-3 cursor-pointer'/>
          <FaUserCircle className='text-3xl mx-3 cursor-pointer'/>
          {
            isLoggedIn ? (
              <Link className='bg-orange-300 text-white font-semibold px-4 py-2 rounded-full ml-3 cursor-pointer hover:bg-orange-400 transition-all'>Log Out</Link>
            ) : (
              <Link 
                to={"/login"}
                className='bg-orange-300 text-white font-semibold px-4 py-2 rounded-full ml-3 cursor-pointer hover:bg-orange-400 transition-all'>Log In</Link>
            )
          }
        </div>


      </div>
    </header>
  )
}

export default Header