module AdventOfCode21.PassagePathing1.CaveSystem

open AdventOfCode21

type CaveName = string

type CaveSize =
    | Small
    | Large

type Cave = { Name: CaveName; Size: CaveSize }

type Path = { From: CaveName; To: CaveName }

type CaveSystem = { Caves: Set<Cave>; Paths: Set<Path> }


let hasName name cave = cave.Name = name

let isSmall cave =
    cave.Size
    |> function
        | Small -> true
        | Large -> false

let isLarge = not << isSmall


let emptySystem = { Caves = Set.empty; Paths = Set.empty }

let tryCaveByName name caveSystem =
    caveSystem.Caves |> Set.tryFind (hasName name)

let startCave caveSystem = caveSystem |> tryCaveByName "start" |> Option.get

let endCave caveSystem = caveSystem |> tryCaveByName "end" |> Option.get

let pathConnects c1 c2 path =
    (path.From = c1.Name && path.To = c2.Name)
    || (path.From = c2.Name && path.To = c1.Name)

let hasPathBetween c1 c2 caveSystem =
    caveSystem.Paths |> Set.exists (pathConnects c1 c2)

let isConnectedTo other caveSystem cave =
    caveSystem |> hasPathBetween cave other

let cavesConnectedTo cave caveSystem =
    caveSystem.Caves
    |> Set.filter (isConnectedTo cave caveSystem)

let rec findAllPathsFrom currentCave pathSoFar caveSystem =

    let hasBeenTo cave = pathSoFar |> List.contains cave.Name

    let canTravelTo cave = cave |> isLarge || (not << hasBeenTo) <| cave

    let findNextPaths cave =
        caveSystem
        |> findAllPathsFrom cave (currentCave.Name :: pathSoFar)

    let travelFurther () =
        caveSystem
        |> cavesConnectedTo currentCave
        |> Set.filter canTravelTo
        |> Set.toList
        |> List.collect findNextPaths

    if currentCave.Name = "end" then
        [ currentCave.Name :: pathSoFar ] |> List.rev
    else
        travelFurther ()

let allPaths caveSystem =
    caveSystem |> findAllPathsFrom (caveSystem |> startCave) []

let pathCount caveSystem = caveSystem |> allPaths |> List.length
