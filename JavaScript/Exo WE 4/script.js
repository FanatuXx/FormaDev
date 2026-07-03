const allCardsContainer = document.getElementById("all-cards");
const animalInfo = document.getElementById("animal-info");
const animals = [
  { name: "Chat",   color: "#f39c12" },
  { name: "Chien",  color: "#3498db" },
  { name: "Lapin",  color: "#e74c3c" },
  { name: "Renard", color: "#2ecc71" },
];

for (animal of animals)
{
    const animalCard = document.createElement('div');
    animalCard.id = animal.name;
    animalCard.classList.add('card');
    animalCard.style.backgroundColor = animal.color;
    const animalName = document.createElement('p');
    animalName.classList.add('name');
    animalName.textContent = animal.name;
    animalCard.appendChild(animalName);

    animalCard.addEventListener('click', () => {
        animalInfo.textContent = `Tu as cliqué sur : ${animalCard.id}`
    });

    allCardsContainer.appendChild(animalCard);
}

