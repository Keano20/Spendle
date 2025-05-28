import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

export default defineConfig({
  plugins: [react()],
  server: {
    port: 5000, // React dev server
    proxy: {
      '/api': {
        target: 'http://localhost:5001', /// ASP.NET Backend
        changeOrigin: true,
        secure: false,
      }
    }
  }
});