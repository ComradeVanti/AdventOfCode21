module AdventOfCode21.Math

let dist a b = abs (a - b)

let isBetween a b n = (dist a n) + (dist b n) = (dist a b)

let isEven n = n % 2 = 0

let isOdd = not << isEven
