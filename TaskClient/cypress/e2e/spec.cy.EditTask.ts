const data1 = {
    "id": 22,
    "title": "SQL actualizacion",
    "description": "Se actualiza tarea",
    "developer": "Sistema",
    "state": "Pendiente"
}

const editTask = () => {
    cy.request("POST", `${endPoint}Task/Edit`, data1)
}


describe('test service with mockup edit task', () => {
    it('editTask', () => {
        editTask()
        cy.get('p-toast-message-text')
            .shadow()
            .find('p-toast-detail')
            .contains('Se ha actualizado la tarea');
    })
})