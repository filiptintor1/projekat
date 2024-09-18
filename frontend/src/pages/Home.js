import React from 'react'
import { Link } from 'react-router-dom'
import { MdHexagon } from "react-icons/md";
import { FaArrowRightLong } from "react-icons/fa6";
import mainImage from "../assets/honeyMainImage.png";
import HoneyMainCard from '../components/HoneyMainCard';



const Home = () => {
  return (
    <section>
      <div className='container max-w-5xl mt-24 flex justify-center items-center mx-auto'>
        {/**Naslov, cta */}
        <div>
          <p className='text-gray-600 mb-6'>Pure, Natural Honey Straight from the Hive</p>
          <h1 className='text-6xl font-bold mb-6'>RAW HONEY</h1>
          <p className='text-gray-400 mb-16'>Discover the rich flavors and health benefits of our premium honey, sourced directly from the hive to your table. Our honey is 100% natural, free from additives, and harvested with care to ensure its purity and quality.</p>
          <div className='relative flex justify-center items-center w-fit'>
            <MdHexagon className='text-orange-400 text-6xl absolute left-0'/>
            <div className='ml-6 flex justify-center items-center'>
              <Link to={'/shop'} className='text-xl font-semibold z-10 mr-2'>Shop now</Link>
              <FaArrowRightLong />
            </div>
          </div>
        </div>

        {/**Slika */}
        <div>
          <img src={mainImage} width={1444} className='hidden md:block'/>
        </div>
      </div>

      <HoneyMainCard />
    </section>
  )
}

export default Home