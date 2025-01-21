import pdfMake from 'pdfmake/build/pdfmake';
import pdfFonts from 'pdfmake/build/vfs_fonts';
import { TextToNumber } from '@/helpers/NumberHelp.js';

//https://pdfmake.github.io/docs/0.1/document-definition-object/page/

pdfMake.vfs = pdfFonts.pdfMake.vfs;

const PrintReceita = (receita, ingredientes) => {
    let docDefinition = {
        info: {
          title: "Receita",
          creationDate: new Date()
        },
        pageSize: {
          width: 400, 
          height: 'auto'
        },
        pageMargins: [10, 10, 10, 10],  /*left, bottom, right, top*/
        content: pdfContent(receita, ingredientes),
        defaultStyle: pdfDefaultStyle(),
        styles: pdfCustomStyles(),
    };
      
    pdfMake.createPdf(docDefinition).open();
    /*pdfMake.createPdf(docDefinition).print();*/
}

const pdfContent = (receita, ingredientes) => {

    let ingredientesPrint = obterIngredientesImpressao(receita, ingredientes);

    return [
        { text: receita.nome, style: 'header', margin: [0,0,0,20] },
        {
          // layout: 'lightHorizontalLines',
          table: {
            headerRows: 1,
            widths: ['*', 'auto'],
            body: ingredientesPrint 
          }
        },
        { text: 'Preparo:', style: 'header2', margin: [0,20,0,5] }, 
        { text: receita.preparo },
        { text: 'Observações', style: 'header2', margin: [0,20,0,0] },          
        { text: receita.observacao }
    ];
}
  
const pdfDefaultStyle = () => {
    return {
        font: 'Roboto',
        fontSize: 12,
        color: "#404040",
        normal: true,          
    };
}

const pdfCustomStyles = () => {
    return {
        header: {
            fontSize: 16,
            bold: true,
            alignment: 'center'
        },
        header2: {
            fontSize: 12,
            bold: true,
            alignment: 'left'
        }
    };
}

const obterIngredientesImpressao = (receita, ingredientes) => {

    var peso1 = receita.pesoReferencia;

    var ingredientesPrint = [[
      'Ingredientes', 
      { text: 'gramas', style: { alignment: 'center'}},         
    ]];

    //ITENS
    ingredientes.map((item) => {
      var percent = TextToNumber(item.percentual).toFixed(2);

      ingredientesPrint.push([ 
        item.nome, 
        { text: (percent / 100 * peso1).toFixed(0), style: { alignment: 'right'} },           
      ]);
    });

    /*var totalPercent = ingredientes.reduce((prev,item) => TextToNumber(item.percentual) + prev,0);*/
    var total1 = ingredientes.reduce((prev,item) => ((TextToNumber(item.percentual) / 100) * peso1) + prev,0);

    //FOOTER
    ingredientesPrint.push([ 
      { text: 'TOTAL', style: { bold: true, fontSize: 12 } }, 
      { text: total1.toFixed(0), style: { bold: true, fontSize: 12, alignment: 'right'}},        
    ]);

    return ingredientesPrint;
  }

export { PrintReceita }