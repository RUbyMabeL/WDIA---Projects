// Set a cross-site cookie for third-party contexts
// document.cookie = `cookie2=value2; SameSite=None; Secure`;
// Set a same-site cookie for first-party contexts
// document.cookie = 'cookie1=value1; SameSite=Lax';

const API_URL = `https://api.thecatapi.com/v1/`;
const API_KEY = "live_OLQLaHy30gq7VRz7RPt8nO6l06F7quDfOMqfPV9UP4PnTPm3JPfvktXnhPTX4tuY";

let id = '';
let currentImageToVoteOn;



function showVoteOptions() {
  document.getElementById("grid").innerHTML = '';

  document.getElementById('vote-options').style.display = 'block';
  document.getElementById('vote-results').style.display = 'none';
  document.getElementById('inner-container').style.display = 'flex';

  showImageToVoteOn();
}

function showImageToVoteOn() {

  const url = `${API_URL}images/search`;

  fetch(url, {
    headers: {
      'x-api-key': API_KEY
    }
  })
    .then((response) => {
      return response.json();
    })
    .then((data) => {
      currentImageToVoteOn = data[0];
      document.getElementById("image-to-vote-on").src = currentImageToVoteOn.url;

      let img = document.getElementById("image-to-vote-on");
      if (img.style.height >= img.style.width) {
        img.style.height = '-webkit-fill-available';
        img.style.width = 'auto';
      } else {
        img.style.width = '-webkit-fill-available';
        img.style.height = 'auto';
      }
    });

}

function vote(value) {

  const url = `${API_URL}votes/`;
  const body = {
    image_id: currentImageToVoteOn.id,
    value
  }
  fetch(url, {
    method: "POST", body: JSON.stringify(body), headers: {
      'content-type': "application/json",
      'x-api-key': API_KEY
    }
  })
    .then((response) => {
      showVoteOptions()
    })
}

function showHistoricVotes() {

  document.getElementById('vote-options').style.display = 'none';
  document.getElementById('vote-results').style.display = 'block';
  document.getElementById('inner-container').style.display = 'none';

  const url = `${API_URL}votes?limit=12&order=DESC`;

  fetch(url, {
    headers: {
      'x-api-key': API_KEY
    }
  })
    .then((response) => {
      return response.json();
    })
    .then((data) => {

      data.map(function (voteData) {

        const imageData = voteData.image
        let a = document.createElement('a');
        let image = document.createElement('img');
        image.setAttribute("class", "display");
        //use the url from the image object
        a.setAttribute('href', imageData.url);
        image.src = imageData.url;

        let gridCell = document.createElement('div');

        if (voteData.value < 0) {
          gridCell.classList.add('red');
        } else {
          gridCell.classList.add('green');
        }

        gridCell.classList.add('col-lg2');

        a.appendChild(image);
        gridCell.appendChild(a);

        document.getElementById('grid').appendChild(gridCell);

      });

    })
    .catch(function (error) {
      console.log(error);
    });

}

showVoteOptions();


// set the height
// let height = screen.height;
let footerheight = document.querySelector('footer').offsetHeight;
let headerheight = document.querySelector('header').offsetHeight;
let mainheight = document.querySelector('main').offsetHeight;
// if (height != footerheight + headerheight + mainheight) {
//   let newfooterheight = height - headerheight - mainheight;
//   document.querySelector('footer').style.height = newfooterheight + 'px';
// }
console.log(mainheight + headerheight)