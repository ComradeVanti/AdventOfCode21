[<RequireQualifiedAccess>]
module AdventOfCode21.IO

open System.IO

let tryReadLines path =
    try
        File.ReadAllLines path |> Array.toList |> Ok
    with
    | _ -> Error "Could not read file"
