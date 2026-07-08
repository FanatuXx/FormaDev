const form = document.getElementById("form");
const cardContainer = document.getElementById("pokemon-card");
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
                throw "Pokemon introuvable dans la base de donnée... Veuillez vérifier l'orthographe";
            }

            else
            {
                errorMessage.text = "";
                const data = res.json();
                console.log(data);
            }
        }

        catch (error) {
            console.log(`Erreur : ${error}`);
        }
    }
}




