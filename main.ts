function usmev3 () {
    basic.showLeds(`
        . # . # .
        . # . # .
        . . . . .
        # . . . #
        # # # # #
        `)
}
input.onLogoEvent(TouchButtonEvent.LongPressed, function () {
    usmev3()
})
function usmev2 () {
    basic.showLeds(`
        . # . # .
        . # . # .
        . . . . .
        # # # # #
        . # # # .
        `)
}
function spanek () {
    basic.showLeds(`
        . . . . .
        # # . # #
        . . . . .
        . . . . .
        . # # # .
        `)
}
input.onLogoEvent(TouchButtonEvent.Touched, function () {
    usmev1()
})
function usmev1 () {
    basic.showLeds(`
        . # . # .
        . # . # .
        . . . . .
        # . . . #
        . # # # .
        `)
}
input.onLogoEvent(TouchButtonEvent.Pressed, function () {
    usmev2()
})
input.onLogoEvent(TouchButtonEvent.Released, function () {
    spanek()
})
spanek()
basic.forever(function () {
	
})
