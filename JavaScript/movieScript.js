const movieListRef = document.getElementById("listOfMovies");
const movieToAddInput = document.getElementById("movieToAdd");
const addButton = document.getElementById("btn");
const errorMessage = document.getElementById("errorMessage");
const movieList = ['Requiem for a Dream', 'The Sound of Metal', 'The Book of Eli', 'Birdman'];

function showMovies()
{
    movieListRef.innerHTML = "";

    for (const movie of movieList)
    {
        const listElement = document.createElement('li');
        const delButton = document.createElement('button');
        listElement.textContent = movie;
        delButton.textContent = 'Enlever';
        movieListRef.appendChild(listElement);
        movieListRef.appendChild(delButton);

        delButton.addEventListener('click', () => {
            const index = movieList.indexOf(movie);
            movieList.splice(index, 1);
            showMovies();
        })
    }
}

showMovies();

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


