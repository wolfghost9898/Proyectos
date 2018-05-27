using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Irony.Ast;
using Irony.Parsing;

namespace WebApplication1
{
    class Calculadora : Grammar
    {

        public Calculadora() : base(caseSensitive: true)
        {




            var mas = ToTerm("+");
            var menos = ToTerm("-");
            var por = ToTerm("*");
            var division = ToTerm("/");
            var potencia = ToTerm("^");

            /*---no terminal----*/
            var INICIO = new NonTerminal("INICIO");
            var EXPRE = new NonTerminal("EXPRE");

            /*------------numero----*/
            NumberLiteral numero = TerminalFactory.CreateCSharpNumber("numero");

            this.Root = INICIO;


            INICIO.Rule = EXPRE;


            EXPRE.Rule = EXPRE + mas + EXPRE
                    | EXPRE + menos + EXPRE
                    | EXPRE + por + EXPRE
                    | EXPRE + division + EXPRE
                    | EXPRE + potencia + EXPRE
                    | numero;


            this.RegisterOperators(1, Associativity.Left, mas, menos);

            this.RegisterOperators(2, Associativity.Left, por, division);

            this.RegisterOperators(2, Associativity.Left, potencia);
        }
    }
}