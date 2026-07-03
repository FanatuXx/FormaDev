const clickBtn = document.getElementById('cliquer');
const resetBtn = document.getElementById('reset');
const clickNumberMessage = document.getElementById("click-number");
let clickNumber = 0;


clickBtn.addEventListener('click', () => pushOnClick());
resetBtn.addEventListener('click', () => pushOnReset());

function pushOnClick() 
{
    clickNumber++;

    if (clickNumber === 11)
    {
        clickNumberMessage.classList.add('red');
    }

    clickNumberMessage.textContent = `Nombre de clics : ${clickNumber}`;
}

function pushOnReset() 
{
    clickNumber = 0;
    clickNumberMessage.classList.remove('red');
    clickNumberMessage.textContent = `Nombre de clics : ${clickNumber}`;
}

