module todo.webapi.todo_service

open FSharp.Json
open Suave
open Suave.Successful
open Suave.RequestErrors

type todo =
    { id: int option
      description: string
      completed: bool }

let mutable data =
    [ for i in 0 .. 10 ->
          { description = ("task " + i.ToString())
            id = Some i
            completed = false } ]

// GETs
let getAll =
             data
             |> Json.serialize
             |> OK

let get id =
    data
    |> List.tryFind (fun x -> x.id.Value = id)
    |> function
    | Some x -> x |> Json.serialize |> OK
    | None -> NOT_FOUND "todo item not found"


// POSTs
let create (body : todo) =
    body |> Json.serialize |> OK

// PUTs
let update id = OK("Updating todo " + id.ToString())
let complete id = OK("Completing todo " + id.ToString())

// DELETEs
let delete id =
    data <- List.filter (fun x -> x.id.Value <> id) data
    NO_CONTENT

//let j = """
//{
//  "id": null,
//  "description": "Mow the lawn",
//  "completed": false
//}
//"""
//open FSharp.Json
//let a:todo = Json.fromJson (UTF8.bytes j)