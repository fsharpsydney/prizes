module Random

open System
open System.Threading
open FSharp.Data


let rec getMember (rnd: Random) members =

    let rec findWinner count ls =

        let printMember m = async {
            do! Async.Sleep 50
            printfn "%s" m }

        match (ls, count) with
        | ([], 0) when members |> Seq.length = 0 -> "No members found" 
        | ([], _) -> members |> findWinner count 
        | (m::ms, 0) -> m
        | (m::ms, _) -> 
            printMember m |> Async.RunSynchronously 
            ms |> findWinner (count - 1) 

    let membersCount = members |> Seq.length
    let winnerIndex = membersCount * 2 + rnd.Next(membersCount)
    let winner = members |> findWinner winnerIndex
    printfn "-> Winner: %s" winner
    Console.ReadLine() |> ignore
    members |> List.filter ((<>) winner) |> getMember rnd



