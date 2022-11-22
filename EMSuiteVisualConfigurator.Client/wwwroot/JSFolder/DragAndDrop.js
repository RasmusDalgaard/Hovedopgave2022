﻿function dragAndDrop(className, objref) {
    const position = { x: 0, y: 0 }
    const startPos = { x: 0, y: 0 }
    var newComp
    const interactable = interact(className)

    interactable.draggable({
        listeners: {
            start(event) {
                newComp = true
                startPos.x, position.x = parseInt(event.target.getAttribute("x"))
                startPos.y, position.y = parseInt(event.target.getAttribute("y"))
                if (position.x != 0 && position.y != 0) {
                    newComp = false
                }
            },
            move(event) {
                position.x += event.dx
                position.y += event.dy
                event.target.style.transform = `translate(${position.x}px, ${position.y}px)`
            },
            end(event) {
                if (!newComp) {
                    if (document.getElementsByClassName('iconmenu')[0].offsetWidth / 2 > position.x) {
                        
                        event.target.style.transform = `translate(${startPos.x}px, ${startPos.y}px)`
                    }
                }
                else if (document.getElementsByClassName('iconmenu')[0].offsetWidth / 2 < position.x) {
                    if (event.target.getAttribute("name") == "zone") {
                        event.target.setAttribute("class", "drag-resize zone")
                    }
                    DotNet.invokeMethodAsync("EMSuiteVisualConfigurator.Client", "addItem", event.target.getAttribute("name"), objref)
                }
                else {
                    position.x = 0
                    position.y = 0
                }
                event.target.setAttribute("x", position.x)
                event.target.setAttribute("y", position.y)
                event.target.style.transform = `translate(${position.x}px, ${position.y}px)`

            },
        }, modifiers: [
            interact.modifiers.restrictRect({
                restriction: '#app > div > main > article > div > div.row.maincontent'
                //endOnly: true
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
            event.stopImmediatePropagation();
            alert(event.relatedTarget.id
                + ' was dropped into '
                + event.target.id
            )            
        }
    }).on('dropactivate', function (event) {
        event.target.classList.add('drop-activated')
    })
}
