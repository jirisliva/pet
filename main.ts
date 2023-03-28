function smutek () {
    basic.showLeds(`
        . . . . .
        . # . # .
        . . . . .
        . # # # .
        # . . . #
        `)
    music.playSoundEffect(music.builtinSoundEffect(soundExpression.sad), SoundExpressionPlayMode.UntilDone)
}
function nevolnost () {
    timer = 0
    basic.showLeds(`
        . # . # .
        # . # . #
        . # . # .
        . . . . .
        . # # # .
        `)
    music.playSoundEffect(music.builtinSoundEffect(soundExpression.giggle), SoundExpressionPlayMode.UntilDone)
}
function hello () {
    timer = 0
    basic.showLeds(`
        . . . . .
        . # . # .
        . . . . .
        . # # # .
        . . . . .
        `)
    music.playSoundEffect(music.builtinSoundEffect(soundExpression.hello), SoundExpressionPlayMode.UntilDone)
}
input.onGesture(Gesture.Shake, function () {
    nevolnost()
})
function happy () {
    timer = 0
    basic.showLeds(`
        . # . # .
        . # . # .
        . . . . .
        # . . . #
        . # # # .
        `)
    music.playSoundEffect(music.builtinSoundEffect(soundExpression.happy), SoundExpressionPlayMode.UntilDone)
}
function spanek () {
    basic.showLeds(`
        . . . . .
        # # . # #
        . . . . .
        . # # # .
        . . . . .
        `)
    music.playSoundEffect(music.builtinSoundEffect(soundExpression.yawn), SoundExpressionPlayMode.UntilDone)
}
input.onLogoEvent(TouchButtonEvent.Touched, function () {
    happy()
})
function dead () {
    basic.showIcon(IconNames.Skull)
    music.playSoundEffect(music.builtinSoundEffect(soundExpression.mysterious), SoundExpressionPlayMode.UntilDone)
}
let timer = 0
timer = 0
hello()
basic.forever(function () {
    basic.pause(1000)
    timer += 1
    if (timer == 20) {
        smutek()
    }
    if (timer == 30) {
        spanek()
    }
    if (timer == 40) {
        dead()
    }
})
