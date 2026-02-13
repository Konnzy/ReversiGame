# Reversi Game

A classic **Reversi (Othello)** desktop game built with **C# WinForms**, featuring an AI opponent with multiple difficulty levels and a clean interactive board.

## 🎮 About the Project

This project is a full implementation of the traditional Reversi board game where the player competes against an AI.  
The game includes a graphical interface, move validation, score tracking, and an AI powered by the Alpha–Beta pruning algorithm.

The player controls **Black**, while the computer plays as **White**.

## ✨ Features

- Classic 8×8 Reversi board
- Player vs Computer gameplay
- AI opponent with selectable difficulty:
  - Easy
  - Normal
  - Hard
- Alpha–Beta pruning decision algorithm
- Real-time score display
- Visual hints for valid moves
- Built-in rules window
- Clean and simple WinForms interface

## 🧠 AI Logic

The AI evaluates possible board states using:

- Alpha–Beta pruning
- Depth-based search:
  - Easy → shallow depth
  - Normal → medium depth
  - Hard → deeper search

This allows the game to scale from beginner-friendly to challenging gameplay.

## 🕹️ How to Play

1. Launch the application.
2. Select a difficulty level.
3. Press **Play**.
4. Click on a valid highlighted cell to place your disc.
5. The AI automatically makes its move after yours.
6. The game ends when neither side can make a move.
7. The winner is the player with the most discs on the board.
