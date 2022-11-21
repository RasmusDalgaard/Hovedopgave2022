function dragAndDrop(className, objref) {
    const position = { x: 0, y: 0 }
    const interactable = interact(className)

        interactable.draggable({
        
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
                DotNet.invokeMethodAsync("EMSuiteVisualConfigurator.Client", "addItem", objref)
                /*if (document.getElementsByClassName('iconmenu')[0].offsetWidth / 2 < position.x) {
                    event.target.setAttribute("x", position.x)
                    event.target.setAttribute("y", position.y)
                    DotNet.invokeMethodAsync("EMSuiteVisualConfigurator.Client", "addItem", objref)
                }
                else {
                    event.target.setAttribute("x", 0)
                    event.target.setAttribute("y", 0)
                    event.target.style.transform = `translate(${0}px, ${0}px)`
                }*/
                console.log(event)
            },
        }, modifiers: [
            /*interact.modifiers.restrictRect({
                //restriction: '.main'
                restriction: '#app > div > main > article > div > div.row.maincontent'
                //endOnly: true
            })*/
                interact.modifiers.restrictRect({
                    restriction: '.dropzone'
                })
        ]
    })
}

function dragResize(className) {
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
    .resizable({
            // resize from all edges and corners
        edges: { left: true, right: true, bottom: true, top: true },
        listeners: {
            move(event) {
                var target = event.target
                var x = (parseFloat(target.getAttribute('x')) || 0)
                var y = (parseFloat(target.getAttribute('y')) || 0)

                // update the element's style
                target.style.width = event.rect.width + 'px'
                target.style.height = event.rect.height + 'px'

                // translate when resizing from top or left edges
                x += event.deltaRect.left
                y += event.deltaRect.top

                target.style.transform = 'translate(' + x + 'px,' + y + 'px)'

                target.setAttribute('x', x)
                target.setAttribute('y', y)
                target.textContent = Math.round(event.rect.width) + '\u00D7' + Math.round(event.rect.height)
            }
        }
    })
}

function dropZone(dropTarget) {
    interact(dropTarget).dropzone({
        ondrop: function (event) {
            alert(event.relatedTarget.id
                + ' was dropped into '
                + event.target.id
            )
            event.stopImmediatePropagation();
        }
    }).on('dropactivate', function (event) {
        event.target.classList.add('drop-activated')
    })
}

/*function resize-drag(className) {

    interact(className).resizable({
        // resize from all edges and corners
        edges: { left: true, right: true, bottom: true, top: true },

        listeners: {
            move(event) {
                var target = event.target
                var x = (parseFloat(target.getAttribute('data-x')) || 0)
                var y = (parseFloat(target.getAttribute('data-y')) || 0)

                // update the element's style
                target.style.width = event.rect.width + 'px'
                target.style.height = event.rect.height + 'px'

                // translate when resizing from top or left edges
                x += event.deltaRect.left
                y += event.deltaRect.top

                target.style.transform = 'translate(' + x + 'px,' + y + 'px)'

                target.setAttribute('data-x', x)
                target.setAttribute('data-y', y)
                target.textContent = Math.round(event.rect.width) + '\u00D7' + Math.round(event.rect.height)
            }
        }
    }).draggable({
        listeners: { move: window.dragMoveListener },
        inertia: true,
        modifiers: [
            interact.modifiers.restrictRect({
                restriction: 'parent',
                endOnly: true
            })]
        }
    )
}*/