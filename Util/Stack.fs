namespace AdventOfCode21

type Stack<'Data> = 'Data list

[<RequireQualifiedAccess>]
module Stack =

    let empty: Stack<_> = []

    let push item (stack: Stack<_>) : Stack<_> = item :: stack

    let pop (stack: Stack<_>) : Stack<_> = stack |> List.tail

    let tryPeek (stack: Stack<_>) = stack |> List.tryHead
