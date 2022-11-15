function dragAndDrop(className) {
    const position = { x: 0, y: 0 }

    interact(className).draggable({
        listeners: {
            start(event) {
                position.x = parseInt(event.target.getAttribute("x"))
                position.y = parseInt(event.target.getAttribute("y"))
            },
            move(event) {
                position.x += event.dx
                position.y += event.dy
                event.target.style.transform = `translate(${position.x}px, ${position.y}px)`
            },
            end(event) {
                event.target.setAttribute("x", position.x)
                event.target.setAttribute("y", position.y)
            },
        }, modifiers: [
            interact.modifiers.restrictRect({
                restriction: '.main'
            })
        ]
    })
};


function dropZone(dropTarget) {
    interact(dropTarget)
        .dropzone({
            ondrop: function (event) {
                alert(event.relatedTarget.id
                    + ' was dropped into '
                    + event.target.id)
            }
        })
        .on('dropactivate', function (event) {
            event.target.classList.add('drop-activated')
        })
}