module ComradeVanti.AC21.SonarSweep1.Scanning

type Depth = int

let countIncreases (depthReadings: Depth list) =

    let isIncrease (prev, num) = num > prev

    depthReadings |> List.pairwise |> List.countWhere isIncrease
