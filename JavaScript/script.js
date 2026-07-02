const gameBoard = document.getElementById('game-board');
const tiles = ['1', '1','2', '2','3', '3','4', '4', '5', '5','6', '6','7', '7','8', '8'];

function showCards()
{
    for (let i = 0; i < 16; i++)
    {
        const cardContainer = document.createElement('div');
        cardContainer.className = 'card';
        cardContainer.id = 'card' + i;
        const frontFace = document.createElement('div');
        frontFace.className = 'front flipped';
        const colorFront = document.createElement('div');
        colorFront.className = 'color-front';
        const backFace = document.createElement('div');
        backFace.className = 'back';
        const colorBack = document.createElement('div');
        colorBack.className = 'color-back';

        backFace.append(colorBack);
        frontFace.append(colorFront);
        cardContainer.append(frontFace, backFace);

        // cardContainer.addEventListener('click', () => {
            
        // })
    }
}

showCards();

addButton.addEventListener('click', () => {
    const movieToAdd = movieToAddInput.value;
    errorMessage.textContent = "";

    if(!movieToAdd)
    {
        errorMessage.textContent = "Vous n'avez pas renseigné de film à ajouter !";
        return;
    }

    movieList.push(movieToAdd);
    movieToAddInput.value = "";
    movieToAddInput.focus();
    showMovies();
})


