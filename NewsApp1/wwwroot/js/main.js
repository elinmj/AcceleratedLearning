console.log("Moi Mukulat!");

async function clickSeed() {

    

    let response = await fetch(`api/news/seed`, {
        method: "POST"
    });


    if (response.status === 204) {

        console.log("Seed done!")

   

    } else {
        console.error("Unexpected error", response)

    }
    

}

let result = "";

async function clickShowAllNews() {


    let response = await fetch(`api/news`, {
        method: "GET"
    });

    if (response.status === 200) {

        result = await response.json();
        console.log(result);

    } else {
        console.error("Unexpected error", response)
    }
    render();
}



function render() {
    let newsList = document.getElementById("newsList");
    for (var i = 0; i < result.length; i++) {
        let news = document.createElement("P");
        news.innerText = result[i].id + "; " + result[i].header + " - " + result[i].intro;
        newsList.appendChild(news);
    }
}

async function clickStatArea() {

    let response = await fetch(`api/news/count`,{
        method: "GET"
    });

    if (response.status === 200) {
        result = await response.text();
        document.getElementById("statArea").innerText = result + " news";
    } else {
        console.error("Unexpected error", response)
    }



}