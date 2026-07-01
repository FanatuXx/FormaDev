const habilitationInput = document.getElementById('habilitation');
const statutInput = document.getElementById('statut');
const timeInput = document.getElementById('arrival');
const button = document.getElementById('btn');
const accessMessage = document.getElementById('access');
const reasonMessage = document.getElementById('reason');

button.addEventListener('click', () => {
    const habilitation = habilitationInput.valueAsNumber;
    const time = timeInput.valueAsNumber;

    if (!habilitation || isNaN(time))
    {
        accessMessage.textContent = "Erreur";
        reasonMessage.textContent = "Vous devez compléter tous les champs";
        return;
    }

    const isCardActive = statutInput.checked;
    const openingHours = time >= 8 && time <= 20;

    if(!isCardActive)
    {
        accessMessage.textContent = "Accès refusé !"; 
        reasonMessage.textContent = "Raison : votre badge est désactivé";
    }

    else
    {
        if (habilitation < 3)
        {
            accessMessage.textContent = "Accès refusé !";
            reasonMessage.textContent = "Raison : votre niveau d'habilitation est insuffisant";
        }

        else if (habilitation >= 3 && habilitation < 5)
        {
            if (!openingHours)
            {
                accessMessage.textContent = "Accès refusé !";
                reasonMessage.textContent = "Raison : vous êtes en dehors des heures autorisées";
            }

            else
            {
                accessMessage.textContent = "Accès autorisé !";
                reasonMessage.textContent = "Bienvenue";
            }
        }

        else
        {
            accessMessage.textContent = "Accès autorisé !";
            reasonMessage.textContent = "Connecté en tant qu'administrateur";
        }
    }
})