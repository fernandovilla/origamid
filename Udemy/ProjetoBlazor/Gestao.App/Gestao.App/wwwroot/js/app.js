function CompanyMaskInit() {
    console.log("Carregando mascaras....");

    LoadCNPJMask();

    LoadCEPMask();    
}

const LoadCNPJMask = () => {
    var cleaveCNPJ;

    var cnpjMask = {
        delimiters: [".", ".", "/", "-"],
        blocks: [2, 3, 3, 4, 2],
        uppercase: !0
    }

    document.querySelector("#cnpj") && (cleaveCNPJ = new Cleave("#cnpj", cnpjMask));
}

const LoadCEPMask = () => {

    var cleaveCEP;

    var cepMask = {
        delimiters: [".", "-"],
        blocks: [2, 3, 3],
        uppercase: !0
    }

    document.querySelector("#cep") && (cleaveCEP = new Cleave("#cep", cepMask));
}