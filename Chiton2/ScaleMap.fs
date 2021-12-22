module AdventOfCode21.Chiton2.ScaleMap

open AdventOfCode21

let upscale map =
    let small = map |> Grid.toList
    let originalW = map |> Grid.width
    let originalH = map |> Grid.height
    let w = originalW * 5
    let h = originalH * 5

    let tile x y = (x / originalW) + (y / originalH)

    let originalValueAt (x, y) =
        small
        |> List.item (y % originalH)
        |> List.item (x % originalW)

    let makeCell (x, y) =
        let unclamped = originalValueAt (x, y) + tile x y
        if unclamped >= 10 then unclamped - 9 else unclamped

    let makeRow y = List.init w (withSnd y >> makeCell)

    List.init h makeRow |> Grid.tryMake
