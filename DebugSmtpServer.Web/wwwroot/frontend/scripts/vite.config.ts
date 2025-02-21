import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

export default defineConfig(({ mode }) => {
  return ({
      plugins: [react()],
      base: '/',
      build: {
          emptyOutDir: mode !== 'development',
          minify: mode !== 'development'
      },
  })
})