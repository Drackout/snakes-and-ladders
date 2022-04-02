# Estrutura do programa

Este documento descreve a estrutura pensada para a implementação do jogo.

## Dados

- O tabuleiro é representado por uma matriz de `SpaceType`.
- `SpaceType` é um enumerado que representa o tipo que uma determinada casa tem.
- Um jogador é representado por um array de comprimento 2.
  Os dois elementos representam a linha e a coluna em que o jogador está,
  por essa ordem.

## Métodos

- gerar tabuleiro
- desenhar tabuleiro (se calhar numa secção à parte)
- mover jogador
