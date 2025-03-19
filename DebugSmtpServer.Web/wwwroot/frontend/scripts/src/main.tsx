import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import rootStore from './store/rootStore.ts'
import { Provider } from 'react-redux'
import { start } from './signalr/signalrConnection.ts'

start().then(x => {
    createRoot(document.getElementById('root')!).render(
        <StrictMode>
            <Provider store={rootStore}>
                <App />
            </Provider>
        </StrictMode>,
    )
}) 
