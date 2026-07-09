const form = document.getElementById("form");
const cardContainer = document.querySelector(".pokemon-card");
const submitBtn = document.getElementById("submit");
const errorMessage = document.getElementById("error-message");
const pokemonInput = document.getElementById("name-number");
const lettersOk = ["a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"];


form.addEventListener("submit", requestInfo); 

function standardisePokemon(pokemonName) {
    
    for (const char of pokemonName)
    {
        if(!lettersOk.includes(char))
        {
            pokemonName = pokemonName.replace(char, ""); 
        }
    }

    pokemonName = pokemonName.toLowerCase();
    console.log(pokemonName);
    return pokemonName;
}



async function requestInfo(event) {
    event.preventDefault();
    const pokemonName = pokemonInput.value;
    const pokemonNameOk = standardisePokemon(pokemonName);

    if (pokemonNameOk === "")
    {
        errorMessage.textContent = "Veuillez inscrire le nom d'un pokémon avant de lancer la recherche !";
        return;
    }

    else
    {
        try {
            const res = await fetch(`https://pokeapi.co/api/v2/pokemon/${pokemonNameOk}`);

            if (!res.ok)
            {
                throw new Error ("Pokemon introuvable dans la base de donnée... Veuillez vérifier l'orthographe");
            }

            else
            {
                errorMessage.text = "";
                const data = await res.json();
                console.log(data);

                const pokemonNameRef = document.createElement('div');
                pokemonNameRef.id = "name";
                pokemonNameRef.textContent = `${pokemonNameOk.charAt(0).toUpperCase() + pokemonNameOk.slice(1)}`;
                cardContainer.appendChild(pokemonNameRef);

                const spriteLink = data.sprites.front_default;
                // const sprite = await fetch(`${spriteLink}`);
                const pokemonSprite = document.createElement('img');
                pokemonSprite.src = spriteLink;
                pokemonSprite.alt = "Image non disponible...";
                pokemonSprite.id = 'sprite';
                cardContainer.appendChild(pokemonSprite);
                
                const typeInfo = data.types[0].type.name;
                const pokemonType = document.createElement('div');
                pokemonType.id = 'type';
                pokemonType.textContent = `Pokemon's type : ${typeInfo}`;
                cardContainer.appendChild(pokemonType);

                const abilitiesInfo = [data.abilities[0].ability.name, data.abilities[1].ability.name];
                const pokemonAbilities = document.createElement('div');
                pokemonAbilities.id = 'abilities';
                pokemonAbilities.textContent = `Available attacks : ${abilitiesInfo[0]}, ${abilitiesInfo[0]}`;
                cardContainer.appendChild(pokemonAbilities);
            }
        }

        catch (error) {
            console.log(`Erreur : ${error}`);
        }
    }
}




