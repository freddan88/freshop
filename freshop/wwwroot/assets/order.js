const pageUrl = document.URL;
const queryString = pageUrl.split('=')[1];
const yourGuidInfo = document.getElementById('yourGuid');
const confirmSection = document.getElementById('confirmation-section');

yourGuidInfo.textContent = queryString;

// confirmSection.innerHTML = "Hello";