// EXO 1
// const input1 = document.getElementById('input1');
// const input2 = document.getElementById('input2');
// const button = document.getElementById('btn');
// const pres = document.getElementById('presentation');

// button.addEventListener('click', () => {
//     const name = input1.value;
//     const age = input2.value;
//     pres.textContent = `Bonjour, je m'appelle ${name} et j'ai ${age} ans.`
// })




// EXO2
// const input1 = document.getElementById('input1');
// const input2 = document.getElementById('input2');
// const button = document.getElementById('btn');
// const res = document.getElementById('res');

// button.addEventListener('click', () => {
//     const weight = input1.valueAsNumber;
//     const height = input2.valueAsNumber / 100;
//     const imc = weight / (height*height);

//     if (imc < 18.5)
//     {
//         res.textContent = `Votre IMC est de ${imc}, ce qui correspond à la catégorie Maigreur.`;
//     }

//     else if (imc >= 18.5 && imc <= 24.9)
//     {
//         res.textContent = `Votre IMC est de ${imc}, ce qui correspond à la catégorie Corpulence normale.`;
//     }

//     else if (imc > 24.9 && imc <= 29.9)
//     {
//         res.textContent = `Votre IMC est de ${imc}, ce qui correspond à la catégorie Surpoids.`;
//     }

//     else
//     {
//         res.textContent = `Votre IMC est de ${imc}, ce qui correspond à la catégorie Obésité.`;
//     }
// })



// EXO2 V2
const input1 = document.getElementById('input1');
const input2 = document.getElementById('input2');
const button = document.getElementById('btn');
const res = document.getElementById('res');

button.addEventListener('click', () => {
    const weight = input1.valueAsNumber;
    const height = input2.valueAsNumber / 100;
    let imc = (weight / (height*height)).toFixed(2);
    let category;

    if(!weight ||!height)
    {
        res.textContent = "Veuillez remplir tous les champs";
        return;
    }

    if (imc < 18.5)
    {
        category = 'Maigreur';
    }

    else if (imc >= 18.5 && imc <= 24.9)
    {
        category = 'Corpulence normale';
    }

    else if (imc > 24.9 && imc <= 29.9)
    {
        category = 'Surpoids';
    }

    else
    {
        category = 'Obésité';
    }

    res.textContent = `Votre IMC est de ${imc}, ce qui correspond à la catégorie ${category}.`;
})





