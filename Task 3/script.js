function getElementAndItsChildrenInArray(domElement) {
    let result = Array.from(domElement.querySelectorAll("*"))
    result.push(domElement); //since the order doesn't matter according to the task, the parent element is added last
    return result;
}

// This function will put the parent element first and then the descendants
function getElementAndItsChildrenInArrayParentFirst(domElement) {
    let result = [domElement];
    Array.from(domElement.querySelectorAll('*')).forEach(element => {
        result.push(element);
    });
    return result;
}

// The function can be called with a click event listener - when clicking on an element, it's result array will be displayed in the console.
document.addEventListener('click', function(e){
    let unorderedResult = getElementAndItsChildrenInArray(e.target);
    let parentFirstResult = getElementAndItsChildrenInArrayParentFirst(e.target);
    console.log(unorderedResult);
    console.log(parentFirstResult);
});