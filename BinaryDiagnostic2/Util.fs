module AdventOfCode21.BinaryDiagnostic2.Util

let binToDec (bin: BinNum) =

    let (^) b n = int ((float b) ** (float n))

    let digitToDec i digit =
        match digit with
        | I -> (2 ^ i)
        | O -> 0

    bin |> List.rev |> List.mapi digitToDec |> List.sum

let countItem item list = list |> List.filter ((=) item) |> List.length

let columns lists =
    let columnCount = lists |> List.head |> List.length

    let getColumn i = lists |> List.map (List.item i)

    List.init columnCount getColumn

let startsWith subList list =

    let matchesAtIndex i item = list |> List.item i = item

    subList |> List.mapi matchesAtIndex |> List.forall id

let findLongestMatch columnFolder lists =

    let rec filterUntilMatch index lists =
        let column = lists |> columns |> List.item index
        let folded = column |> columnFolder

        lists
        |> List.filter (List.item index >> (=) folded)
        |> function
            | [ single ] -> single
            | remaining -> remaining |> filterUntilMatch (index + 1)

    lists |> filterUntilMatch 0
