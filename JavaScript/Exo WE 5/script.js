const questionNumber = document.getElementById("question-number");
const question = document.getElementById("question");
const answerContainer = document.getElementById("answer-container");
const checkCorrectMessage = document.getElementById("right-or-false");
const scoreMessage = document.getElementById("score-message");
const ingameText = document.getElementById("unfinished-game");

const questionDetails = [
  {
    question: "Quelle est la capitale de la France ?",
    answer: ["Londres", "Paris", "Madrid"],
    right: "Paris"
  },
  {
    question: "Combien font 7 x 8 ?",
    answer: ["54", "56", "64"],
    right: "56"
  },
  {
    question: "Quel langage s'exécute dans le navigateur ?",
    answer: ["Python", "Java", "JavaScript"],
    right: "JavaScript"
  }
];

let boutons = [];

let questionIndex = 0;
let score = 0;

showQuestion();

function showQuestion()
{
  
  if(questionIndex < questionDetails.length)
  {
    answerContainer.innerHTML = "";
    boutons = [];
    questionNumber.textContent = `Question ${questionIndex + 1}/3`;
    question.textContent = questionDetails[questionIndex].question;

    for (const response of questionDetails[questionIndex].answer)
    {
      const answerPossibility = document.createElement("button");
      boutons.push(answerPossibility);
      answerPossibility.classList.add("answer");
      answerPossibility.textContent = response;

      answerPossibility.addEventListener('click', () => checkAnswer(response));  

      answerContainer.appendChild(answerPossibility);
    }
  }

  else
  {
    showFinalScore();
  }
}


function showFinalScore()
{
  ingameText.innerHTML = "";
  scoreMessage.textContent = `Félécitations ! Vous avez marqué ${score} point(s).`;
}


function checkAnswer(response)
{
  checkCorrectMessage.className = "";

  if (response === questionDetails[questionIndex].right)
  {
    checkCorrectMessage.classList.add("correct");
    checkCorrectMessage.textContent = "✅ Correct !";
    score++;
  }

  else
  {
    checkCorrectMessage.classList.add("incorrect");
    checkCorrectMessage.textContent = "❌ Incorrect !";
  }

  boutons.forEach(btn => btn.disabled = true);
  questionIndex++;
  setTimeout(showQuestion, 1000);
}