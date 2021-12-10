namespace AdventOfCode21

type Stack<'Data> = 'Data list

[<RequireQualifiedAccess>]
module Stack =

    let empty: Stack<_> = []

    let push item (stack: Stack<_>) : Stack<_> = item :: stack

    let pop (stack: Stack<_>) : Stack<_> =
        match stack with
        | [] -> []
        | _ :: tail -> tail

    let tryPeek (stack: Stack<_>) = stack |> List.tryHead

    let fromList (list: _ list) : Stack<_> = list

    let toList (stack: Stack<_>) : _ list = stack
