/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["**/*.{html,cshtml}"],
  theme: {
    extend: {},
  },
  plugins: [
    require('@tailwindcss/forms'),
    require('@tailwindcss/typography'),
  ],
}
