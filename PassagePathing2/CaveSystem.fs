module AdventOfCode21.PassagePathing2.CaveSystem

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

let pathConnects caveName cave path =
    (path.From = caveName && path.To = cave.Name)
    || (path.From = cave.Name && path.To = caveName)

let hasPathBetween caveName cave caveSystem =
    caveSystem.Paths |> Set.exists (pathConnects caveName cave)

let isConnectedTo caveName caveSystem other =
    caveSystem |> hasPathBetween caveName other

let cavesConnectedTo caveName caveSystem =
    caveSystem.Caves
    |> Set.filter (isConnectedTo caveName caveSystem)

let rec findAllPathsFrom pathSoFar caveSystem =

    let currentCaveName = pathSoFar |> List.head

    let hasBeenToSmallCaveTwice =
        pathSoFar
        |> List.filter String.isLower
        |> List.hasDuplicates

    let visitCount cave = pathSoFar |> List.countItem cave.Name

    let canTravelTo cave =
        let isLarge = cave |> isLarge
        let visitCount = cave |> visitCount
        let isStart = cave.Name = "start"
        let neverVisited = visitCount = 0

        let canVisitAgain =
            visitCount = 1
            && not <| hasBeenToSmallCaveTwice
            && not <| isStart

        isLarge || neverVisited || canVisitAgain

    let findNextPaths cave =
        caveSystem |> findAllPathsFrom (cave.Name :: pathSoFar)

    let travelFurther () =
        caveSystem
        |> cavesConnectedTo currentCaveName
        |> Set.filter canTravelTo
        |> Set.toList
        |> List.collect findNextPaths

    if currentCaveName = "end" then
        [ currentCaveName :: pathSoFar |> List.rev ]
    else
        travelFurther ()

let allPaths caveSystem =
    caveSystem
    |> findAllPathsFrom [ (caveSystem |> startCave).Name ]

let pathCount caveSystem =
    let paths = caveSystem |> allPaths
    paths |> List.length
