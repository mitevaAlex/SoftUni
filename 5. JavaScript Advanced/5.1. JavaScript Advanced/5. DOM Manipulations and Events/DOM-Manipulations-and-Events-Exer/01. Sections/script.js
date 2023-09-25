function create(words) {
   for (let word of words) {
      let section = document.createElement('div');
      let paragraph = document.createElement('p');
      paragraph.style.display = 'none';
      paragraph.textContent = word;
      section.appendChild(paragraph);
      section.addEventListener('click', showText);
      document.getElementById('content').appendChild(section);
   }

   function showText(event) {
      event.target.getElementsByTagName('p')[0].style.display = 'block';
   }
}