const input1 = document.getElementById('input1');
const input3 = document.getElementById('input3').;
const button = document.getElementById('btn');
const res = document.getElementById('res');

button.addEventListener('click', () => {
    const habilitation = input1.valueAsNumber;
    const isActive = document.getElementById('input2').checked;
    const time = input3.value.getHours();

    if(!isActive)
    {
        res.textContent = "Accès refusé ! Raison : votre badge est désactivé";
    }

    else
    {
        if (habilitation < 3)
        {
            res.textContent = "Accès refusé ! Raison : Votre niveau d'habilitation est insuffisant";
        }

        else if (habilitation > 3 && habilitation < 5)
        {
            if (time.getHours() < 8 && time.getHours > 20)
            {
                res.textContent = "Accès refusé ! Raison : Vous êtes en dehors des heures autorisées";
            }

            else
            {
                res.textContent = "Accès autorisé !";
            }
        }

        else
        {
            res.textContent = "Accès autorisé !";
        }
    }

    
})