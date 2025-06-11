/** @type {import('tailwindcss').Config} */
export default {
    content: [
        "./index.html",
        "./src/**/*.{js,ts,jsx,tsx}",
    ],
    theme: {
        extend: {
            colors: {
                sand:'#D9C5B2',
                teal:'#00BFB2',
                charcoal:'#363635',
                lightgrey:'#F3F3F4',
            }
        },
    },
    plugins: [],
}