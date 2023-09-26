var numberOfItems=0;
function setCartNumber(number) {
    var element = document.getElementById("cartNumber");
    if (element)
        element.innerHTML = number;
    if (number == 0)
        element.innerHTML = "";
    numberOfItems = number;
}
function increaseCartNumber() {
    var element = document.getElementById("cartNumber");
    numberOfItems += 1;
    if (element) {
        element.innerHTML = numberOfItems;
    }    
}
function decreaseCartNumber() {
    var element = document.getElementById("cartNumber");
    numberOfItems -= 1;
    if (element) {
        if (numberOfItems > 0)
            element.innerHTML = numberOfItems;
        else element.innerHTML = "";
    }
}
function setNum() {
    setCartNumber(numberOfItems);
}