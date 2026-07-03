const colorZone = document.getElementById("color-zone");
const colorCode = document.getElementById("color-code");
const redBtn = document.getElementById("red");
const greenBtn = document.getElementById("green");
const blueBtn = document.getElementById("blue");
const randomBtn = document.getElementById("random");
const buttons = document.querySelectorAll(".button");

let r = 0;
let g = 0;
let b = 0;

buttons.forEach(button => {
    const buttonColor = button.id;
    button.addEventListener('click', () => changeColor(buttonColor));
})

function changeColor(buttonColor)
{
    switch (buttonColor)
    {
        case 'red':
            r = 255;
            g = 0;
            b = 0;
            break;

        case 'green':
            r = 0;
            g = 128;
            b = 0;
            break;

        case 'blue':
            r = 0;
            g = 0;
            b = 255;
            break;

        case 'random':
            r = Math.floor(Math.random() * 256);
            g = Math.floor(Math.random() * 256);
            b = Math.floor(Math.random() * 256);
            break;
    }

    const color = `rgb(${r}, ${g}, ${b})`;
    colorZone.style.backgroundColor = color;

    const rgb2hex = (rgb) => `#${rgb.match(/^rgb\((\d+),\s*(\d+),\s*(\d+)\)$/).slice(1).map(n => parseInt(n, 10).toString(16).padStart(2, '0')).join('')}`
    colorCode.textContent = `Couleur actuelle (hex): ${rgb2hex(color)}`;
}

