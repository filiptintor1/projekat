import React, { useState } from 'react'
import { FaRegEye } from "react-icons/fa";
import { FaRegEyeSlash } from "react-icons/fa";
import { Link } from 'react-router-dom';

const SignUp = () => {
  const [showPassword, setShowPassword] = useState(false)
    const [data, setData] = useState({
        username: "",
        email: "",
        password: "",
        confPassword: ""
    })

    const handleOnChange = (e) => {
        const { name, value } = e.target;

        setData((preve) => {
            return {
                ...preve,
                [name]: value
            }
        })

        console.log(data)
    }


    return (
      <section id='login'>
          <div className='mx-auto container p-4'>
              <div className='bg-white p-5 w-full max-w-sm mx-auto shadow-lg rounded-3xl block mt-8 mb-8'>
                  <div className='text-center font-semibold text-4xl'>Create Account!</div>
                  <div className='text-center'>Enter your details to get in!</div>
                  <form className='pt-6 flex flex-col gap-4'>
                      <div className='grid'>
                          <label className='mb-2'>Username :</label>
                          <div className='border py-2 px-4 rounded-xl'>
                              <input
                                  type='text'
                                  placeholder='Enter username'
                                  name='username'
                                  value={data.username}
                                  onChange={handleOnChange}
                                  className='w-full h-full outline-none bg-transparent'
                              />
                          </div>
                      </div>

                      <div className='grid'>
                          <label className='mb-2'>Email :</label>
                          <div className='border py-2 px-4 rounded-xl'>
                              <input
                                  type='email'
                                  placeholder='Enter your email'
                                  name='email'
                                  value={data.email}
                                  onChange={handleOnChange}
                                  className='w-full h-full outline-none bg-transparent'
                              />
                          </div>
                      </div>
  
                      <div className='grid'>
                          <label className='mb-2'>Password :</label>
                          <div className='border py-2.5 px-4 rounded-xl flex justify-center items-center'>
                              <input
                                  type='password'
                                  placeholder='Password'
                                  name='password'
                                  value={data.password}
                                  onChange={handleOnChange}
                                  className='w-full h-full outline-none bg-transparent'
                              />
                              <div className='cursor-pointer text-xl' onClick={() => setShowPassword((preve) => !preve)}>
                                  <span>
                                      {
                                          showPassword ? <FaRegEye /> : <FaRegEyeSlash />
                                      }
                                  </span>
                              </div>
                          </div>
                      </div>

                      <div className='grid'>
                          <label className='mb-2'>Confirm Password :</label>
                          <div className='border py-2.5 px-4 rounded-xl flex justify-center items-center'>
                              <input
                                  type='password'
                                  placeholder='Confirm Password'
                                  name='password'
                                  value={data.confPassword}
                                  onChange={handleOnChange}
                                  className='w-full h-full outline-none bg-transparent'
                              />
                              <div className='cursor-pointer text-xl' onClick={() => setShowPassword((preve) => !preve)}>
                                  <span>
                                      {
                                          showPassword ? <FaRegEye /> : <FaRegEyeSlash />
                                      }
                                  </span>
                              </div>
                          </div>
                      </div>
  
                     <button className='bg-orange-300 text-white px-6 py-2 w-full max-w-[150px] rounded-full hover:bg-orange-400 mx-auto mt-6 transition-all'>
                      Register
                     </button>
                  </form> 
  
                  <p className='my-8 text-center'>Already have account? <Link to={"/login"} className='text-orange-400 font-semibold'>Login</Link></p>
              </div>
  
              
  
          </div>
      </section>
    )
  
}

export default SignUp