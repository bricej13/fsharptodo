open Suave
open Suave.Filters
open Suave.Operators
open todo.webapi

let app =
    choose [ GET
             >=> choose [ pathCi "/todos" >=> todo_service.getAll
                          pathScanCi "/todos/%d" todo_service.get ]
             POST
             >=> choose [ pathCi "/todos" >=> todo_service.create ]
             PUT
             >=> choose [ pathScanCi "/todos/%d" todo_service.update
                          pathScanCi "/todos/%d/complete" todo_service.complete ]
             DELETE
             >=> choose [ pathScanCi "/todos/%d" todo_service.delete ]
             RequestErrors.NOT_FOUND "not found" ]


startWebServer defaultConfig app
