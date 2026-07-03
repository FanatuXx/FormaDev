const addBtn = document.getElementById("add-button");
const shoppingListContainer = document.getElementById("shopping-list");
const itemInput = document.getElementById("item-input");
const emptyMessage = document.getElementById("empty-message");
let itemsTable = [];

createList();

addBtn.addEventListener('click', () => addItemToTable())

function addItemToTable()
{
    const itemName = itemInput.value;
    itemsTable.push(itemName);
    createList();
}


function createList()
{
    shoppingListContainer.innerHTML = '';

    if (itemsTable.length > 0)
    {
        emptyMessage.textContent = "";

        for (const item of itemsTable)
        {
            const shoppingItem = document.createElement('li');
            shoppingItem.classList.add('shopping-item');
            shoppingItem.textContent = `🛒 ${item}`;
            const delBtn = document.createElement('button');
            delBtn.classList.add('delete-button');
            delBtn.textContent = ' Supprimer ';

            shoppingListContainer.appendChild(shoppingItem);
            shoppingListContainer.appendChild(delBtn);        

            delBtn.addEventListener('click', () => removeItem(item));
        }
    }
    
    else
    {
        emptyMessage.textContent = "Votre liste est actuellement vide";
    }

    itemInput.value = "";
    itemInput.focus();
}

function removeItem(item)
{
    let index = itemsTable.indexOf(item);
    itemsTable.splice(index, 1);
    createList();
}