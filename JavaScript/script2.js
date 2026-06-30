EXO3
const input1 = document.getElementById('input1');
const button = document.getElementById('btn');
const res = document.getElementById('res');

button.addEventListener('click', () => {
    const birthDateValue = input1.value;

    if(!birthDateValue)
    {
        res.textContent = "Encode ta date de naissance";
        return;
    }

    const now = new Date();
    const birthDate = new Date(birthDateValue);

    if (birthDate > now)
    {
        res.textContent = "Tu ne peux pas être né dans le futur";
        return;
    }

    let years = now.getFullYear() - birthDate.getFullYear();
    let months = now.getMonth() - birthDate.getMonth();
    let days = now.getDate() - birthDate.getDate();

    if (days < 0)
    {
        months--;

        const daysInLastMonth = new Date(
            now.getFullYear(),
            now.getMonth(),
            0
        ).getDate(); //getDate permet de trouver le nombre de JOURS
                     //getDay permet de trouver le JOUR DE LA SEMAINE !

        days += daysInLastMonth;
    }

    if (months < 0) 
    {
        years--;
        months += 12;
    }

    res.textContent = "Vous avez : \n" + years + " an(s)\n" + months + " mois\n" + days + " jour(s)";
})