let nb: number = 5;
let title: string = 'Titre';
const movieTitleTab: string[] = ['titre1', 'titre2'];

function mySum(a: number, b: number): number {
    return a + b;
};

const req = mySum(1, 2);

function auPif(): void {
    console.log('Hello');
    return;
}

type Address = {
    street: string;
    zipCode: number;
    streetNumber: number;
};

type Person = {
    name: string;
    age: number;
    address: Address;
    email: string; 
};

const p1: Person = {
    name: 'Davit',
    address: {
        street: 'myStreet',
        streetNumber: 9,
        zipCode: 1140
    },
    age: 28,
    email: "antoine.blabla"
};

function recupPerson(person: Person) {console.log(person.name);}


