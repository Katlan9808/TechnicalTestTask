let endPoint = 'https://localhost:7109/api/';


const data2 = {
    "title": "Se actualiza la tarea",
    "description": "Nueva tarea",
    "developer": "Sistema",
    "state": "Completado"
}

const saveTask = () => {
    cy.request("POST", `${endPoint}Task/Save`, data2)
}


describe('test service with mockup save task', () => {
    it('saveTask', () => {
        saveTask()
        cy.get('p-toast-message-text')
            .shadow()
            .find('p-toast-detail')
            .contains('Se ha agregado la tarea');
    })
})