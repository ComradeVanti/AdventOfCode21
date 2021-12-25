[<AutoOpen>]
module AdventOfCode21.TupleUtil

let withSnd snd fst = fst, snd

let mapBoth f (a, b) = (f a, f b)

let mapSnd f (a, b) = (a, f b)

let mapFst f (a, b) = f a, b
