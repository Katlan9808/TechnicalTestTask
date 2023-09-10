let data3 = {
    "id": 22,
}


const deleteTask = () => {
    cy.request("POST", `${endPoint}Task/Edit`, data3)
}


describe('test service with mockup edit task', () => {
    it('editTask', () => {
        deleteTask()
        cy.get('p-toast-message-text')
            .shadow()
            .find('p-toast-detail')
            .contains('Se ha eliminado la tarea');
    })
})