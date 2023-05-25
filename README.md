# ArceusCreations

Mission Statement

An application that targets pokemon fans with creative minds who desire the ability to create their own pokemon.  Along with creating their own pokemon comes the ability to create new custom moves as well as new typing to give their pokemon and moves.  

Tables

Table 1 : Types
Id <int> PK
Name <string>

Table 2 : Moves
Id <int> PK
Name <string>
TypeId <FK to Types>
Damage <int>
PowerPoints <int>

Table 3 : Pokemon
Id <int> PK
Name <string>
Hp <int>
OwnerId <FK to Users>
TypeId <FK to Types> (collection for dual types)
Move1Id <FK to Moves>
Move2Id <FK to Moves>
Move3Id <FK to Moves>
Move4Id <FK to Moves>
  
Version 1.0 / MVP

Create user profile
Create custom pokemon
Create custom moves
Create custom typing
Search pokemon by type
Search pokemon by name
Search moves by type
Search moves by name

  
Version 2.0 / Stretch Goals
Search moves by damage
Create custom pokemon teams
Edit teams to switch pokemon
Admin role functionality
Base battle functionality

  
Planning Documentation
  https://docs.google.com/document/d/1MqCOcDeXfSQowXsPbCXxoyxaB_Fe-Lm47JaI33_kk74/edit#


