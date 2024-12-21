import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Button from '@mui/material/Button'
import MailsList from './components/mailsList/mailsList'

function App() {

    return (
        <>
            <div className='basic-template'>
                <div className='basic-template__left'>
                    <MailsList></MailsList>
                </div>
                <div className='basic-template__right'>
                   
                </div>
            </div>
        </>
    )
}

export default App
