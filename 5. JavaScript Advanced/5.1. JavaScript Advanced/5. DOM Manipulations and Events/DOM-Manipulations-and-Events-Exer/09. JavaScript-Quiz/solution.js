function solve() {
    let answers = Array.from(document.getElementsByClassName('answer-text'));
    answers.forEach(x => x.addEventListener('click', showNext));

    let questionSections = document.getElementsByTagName('section');
    let questionCounter = 0;
    let rightAnswersCount = 0;

    function showNext(event) {
        let answer = event.target.textContent;
        if (answer === 'onclick' ||
            answer === 'JSON.stringify()' ||
            answer === 'A programming API for HTML and XML documents') {
            rightAnswersCount++;
        }

        questionSections[questionCounter].style.display = 'none';
        questionCounter++;
        if (questionCounter < questionSections.length) {
            questionSections[questionCounter].style.display = 'block';
        } else {
            let result;
            if (rightAnswersCount === questionSections.length) {
                result = 'You are recognized as top JavaScript fan!';
            } else {
                result = `You have ${rightAnswersCount} right answers`;
            }

            document.getElementById('results').style.display = 'block';
            document.querySelector('.results-inner h1').textContent = result;
        }
    }
}